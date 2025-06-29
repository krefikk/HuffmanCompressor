#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <time.h>

#define DLL_EXPORT __declspec(dllexport)
#define MAX_FILENAME_LENGTH 500
#define HEAP_CAPACITY 300
#define MAX_BITS 100

typedef struct Node {
    char ch;
    char bits[MAX_BITS];
    int freq;
    struct Node* left;
    struct Node* right;
} NODE;

typedef struct MinHeap {
    int size;
    NODE** heap;
} MIN_HEAP;

// Function prototypes
NODE* createNode(char ch, int freq);
NODE** countFrequencies(char* inputFileName);
MIN_HEAP* createMinHeap();
void insertToMinHeap(MIN_HEAP* minHeap, NODE* node);
void minHeapify(MIN_HEAP* minHeap, int idx);
void swapNodes(NODE** a, NODE** b);
NODE* peekFromMinHeap(MIN_HEAP* minHeap);
void deleteFromMinHeap(MIN_HEAP* minHeap);
NODE* buildHuffmanTree(MIN_HEAP* minHeap);
void generateHuffmanCodes(NODE* root, char* currentCode, int index);
DLL_EXPORT char* compressFile(char* inputFileName);
DLL_EXPORT char* decompressFile(char* compressedFileName, char* keyFileName);
long getSize(char* filename);
void writeKeyFile(NODE* root, char* keyFileName);
void writeKeyFileHelper(NODE* root, char* currentCode, int index, FILE* keyFile);
void getDirectoryPath(char* fullPath, char* dirPath);

char* toString(NODE* node) {
    char* result = (char*)malloc(MAX_BITS * 5 * sizeof(char));

    if (node->ch == '\0' && node->bits[0] == '\0') {
        sprintf(result, "NULL NULL %d", node->freq);
    } 
    else if (node->ch == '\0') {
        sprintf(result, "NULL %s %d", node->bits, node->freq);
    } 
    else if (node->bits[0] == '\0') {
        if (node->ch == '\n') {
            sprintf(result, "\\n NULL %d", node->freq);
        } else if (node->ch == ' ') {
            sprintf(result, "SPACE NULL %d", node->freq);
        } else {
            sprintf(result, "%c NULL %d", node->ch, node->freq);
        }
    }
    else {
        if (node->ch == '\n') {
            sprintf(result, "\\n %s %d", node->bits, node->freq);
        } else if (node->ch == ' ') {
            sprintf(result, "SPACE %s %d", node->bits, node->freq);
        } else {
            sprintf(result, "%c %s %d", node->ch, node->bits, node->freq);
        }
    }

    return result;
}

NODE* createNode(char ch, int freq) {
    NODE* newNode = (NODE*)malloc(sizeof(NODE));
    newNode->ch = ch;
    newNode->freq = freq;
    newNode->left = newNode->right = NULL;
    newNode->bits[0] = '\0';
    return newNode;
}

NODE** countFrequencies(char* inputFileName) {
    FILE* file = fopen(inputFileName, "r");
    if (file == NULL) {
        printf("Error: Could not open file\n");
        return NULL;
    }

    NODE** freq = (NODE**)calloc(256, sizeof(NODE*));
    int ch;
    int i;

    while ((ch = fgetc(file)) != EOF) {
        if (freq[ch] == NULL) {
            freq[ch] = createNode((char)ch, 0);
        }
        freq[ch]->freq++;
    }

    fclose(file);
    return freq;
}

MIN_HEAP* createMinHeap() {
    MIN_HEAP* minHeap = (MIN_HEAP*)malloc(sizeof(MIN_HEAP));
    minHeap->size = 0;
    minHeap->heap = (NODE**)malloc(HEAP_CAPACITY * sizeof(NODE*));
    return minHeap;
}

MIN_HEAP* buildMinHeap(NODE** freq) {
    MIN_HEAP* minHeap = createMinHeap();
    int i;

    for (i = 0; i < 256; i++) {
        if (freq[i] != NULL) {
            insertToMinHeap(minHeap, freq[i]);
        }
    }

    return minHeap;
}

void swapNodes(NODE** a, NODE** b) {
    NODE* temp = *a;
    *a = *b;
    *b = temp;
}

void minHeapify(MIN_HEAP* minHeap, int idx) {
    int smallest = idx;
    int left = 2 * idx + 1;
    int right = 2 * idx + 2;

    if (left < minHeap->size && minHeap->heap[left]->freq < minHeap->heap[smallest]->freq) {
        smallest = left;
    }

    if (right < minHeap->size && minHeap->heap[right]->freq < minHeap->heap[smallest]->freq) {
        smallest = right;
    }

    if (smallest != idx) {
        swapNodes(&minHeap->heap[idx], &minHeap->heap[smallest]);
        minHeapify(minHeap, smallest);
    }
}

void insertToMinHeap(MIN_HEAP* minHeap, NODE* node) {
    if (minHeap->size >= HEAP_CAPACITY) {
        printf("Heap is full\n");
        return;
    }

    minHeap->size++;
    int i = minHeap->size - 1;
    minHeap->heap[i] = node;

    // Bubble up
    while (i > 0 && minHeap->heap[(i - 1) / 2]->freq > minHeap->heap[i]->freq) {
        swapNodes(&minHeap->heap[i], &minHeap->heap[(i - 1) / 2]);
        i = (i - 1) / 2;
    }
}

void deleteFromMinHeap(MIN_HEAP* minHeap) {
    if (minHeap->size <= 0) {
        printf("Heap is empty\n");
        return;
    }

    NODE* root = minHeap->heap[0];
    minHeap->heap[0] = minHeap->heap[minHeap->size - 1];
    minHeap->size--;

    free(root);
    minHeapify(minHeap, 0);
}

NODE* peekFromMinHeap(MIN_HEAP* minHeap) {
    if (minHeap->size <= 0) {
        printf("Heap is empty\n");
        return NULL;
    }

    NODE* root = minHeap->heap[0];

    minHeap->heap[0] = minHeap->heap[minHeap->size - 1];
    minHeap->size--;

    minHeapify(minHeap, 0);

    return root;
}

NODE* buildHuffmanTree(MIN_HEAP* minHeap) {
    NODE *left, *right, *top;

    while(minHeap->size > 1) {
        left = peekFromMinHeap(minHeap);
        right = peekFromMinHeap(minHeap);

        top = createNode('\0', left->freq + right->freq);
        top->left = left;
        top->right = right;
        insertToMinHeap(minHeap, top);
    }

    return peekFromMinHeap(minHeap);
}

void generateHuffmanCodes(NODE* root, char* currentCode, int index) {
    if (root == NULL) {
        return;
    }

    if (root->left == NULL && root->right == NULL) {
        int i;
        for (i = 0; i < index; i++) {
            root->bits[i] = currentCode[i];
        }
        root->bits[i] = '\0';
        return;
    }

    if (root->left != NULL) {
        currentCode[index] = '0';
        generateHuffmanCodes(root->left, currentCode, index + 1);
    }

    if (root->right != NULL) {
        currentCode[index] = '1';
        generateHuffmanCodes(root->right, currentCode, index + 1);
    }
}

void writeKeyFile(NODE* root, char* keyFileName) {
    FILE* keyFile = fopen(keyFileName, "w");
    if (keyFile == NULL) {
        printf("Error: Could not open key file\n");
        return;
    }

    char* currentCode = (char*)malloc(MAX_BITS * sizeof(char));
    currentCode[0] = '\0';
    
    writeKeyFileHelper(root, currentCode, 0, keyFile);
    
    free(currentCode);
    fclose(keyFile);
}

void writeKeyFileHelper(NODE* root, char* currentCode, int index, FILE* keyFile) {
    if (root == NULL) {
        return;
    }

    if (root->left == NULL && root->right == NULL) {
        char* str = toString(root);
        fprintf(keyFile, "%s\n", str);
        free(str);
        return;
    }

    if (root->left != NULL) {
        currentCode[index] = '0';
        writeKeyFileHelper(root->left, currentCode, index + 1, keyFile);
    }

    if (root->right != NULL) {
        currentCode[index] = '1';
        writeKeyFileHelper(root->right, currentCode, index + 1, keyFile);
    }
}

void freeHuffmanTree(NODE* root) {
    if (root == NULL) {
        return;
    }

    if (root->left != NULL) {
        freeHuffmanTree(root->left);
    }

    if (root->right != NULL) {
        freeHuffmanTree(root->right);
    }

    free(root);
}

DLL_EXPORT char* compressFile(char* inputFileName) {
	char compressedFilePath[MAX_FILENAME_LENGTH];
	char keyFilePath[MAX_FILENAME_LENGTH];
    char dirPath[MAX_FILENAME_LENGTH];
    
	getDirectoryPath(inputFileName, dirPath);
	sprintf(compressedFilePath, "%scompressed.txt", dirPath);
	sprintf(keyFilePath, "%skey.txt", dirPath);
	
    NODE** freq = countFrequencies(inputFileName);
    if (freq == NULL) {
    	static char log[256];
    	strcpy(log, "Error: Could not count frequencies.");
        return log;
    }

    MIN_HEAP* minHeap = buildMinHeap(freq);
    if (minHeap == NULL || minHeap->size == 0) {
        static char log[256];
    	strcpy(log, "Error: Could not build min heap.");
    	free(freq);
        return log;
    }

    NODE* root = buildHuffmanTree(minHeap);
    if (root == NULL) {
        static char log[256];
    	strcpy(log, "Error: Could not build Huffman tree.");
    	free(freq);
    	free(minHeap);
        return log;
    }  

    char* currentCode = (char*)malloc(MAX_BITS * sizeof(char));    
    currentCode[0] = '\0';
    generateHuffmanCodes(root, currentCode, 0); 
    free(currentCode);

    // Calculate total bits first
    FILE* inputFile = fopen(inputFileName, "r");
    if (inputFile == NULL) {
        static char log[256];
    	strcpy(log, "Error: Could not open input file.");
    	free(freq);
    	free(minHeap);
    	free(root);
        return log;
    }

    int totalBits = 0;
    int ch;
    while ((ch = fgetc(inputFile)) != EOF) {
        totalBits += strlen(freq[ch]->bits);
    }
    fclose(inputFile);

    // Write key file with total bits
    FILE* keyFile = fopen(keyFilePath, "w");
    if (keyFile == NULL) {
        static char log[256];
    	strcpy(log, "Error: Could not open key file.");
    	free(freq);
    	free(minHeap);
    	free(root);
        return log;
    }

    // Write total bits at the beginning
    fprintf(keyFile, "TOTAL_BITS %d\n", totalBits);
    
    // Write character codes
    char* currentCode2 = (char*)malloc(MAX_BITS * sizeof(char));
    currentCode2[0] = '\0';
    writeKeyFileHelper(root, currentCode2, 0, keyFile);
    free(currentCode2);
    fclose(keyFile);

    // Now compress the file
    inputFile = fopen(inputFileName, "r");
    FILE* outputFile = fopen(compressedFilePath, "wb");
    if (outputFile == NULL) {
        static char log[256];
    	strcpy(log, "Error: Could not open output file.");
    	free(freq);
    	free(minHeap);
    	free(root);
        return log;
    }

    char* huffmanCode = (char*)malloc(MAX_BITS * sizeof(char));
    unsigned char byte = 0;
    int i, bitCount = 0;
    
    while ((ch = fgetc(inputFile)) != EOF) {
        strcpy(huffmanCode, freq[ch]->bits);
        for (i = 0; i < strlen(huffmanCode); i++) {
            // Add bit to current byte (MSB first)
            byte = (byte << 1) | (huffmanCode[i] - '0');
            bitCount++;
            
            // When we have 8 bits, write the byte
            if (bitCount == 8) {
                fputc(byte, outputFile);
                byte = 0;
                bitCount = 0;
            }
        }
    }
    
    // Write remaining bits (pad with zeros)
    if (bitCount > 0) {
        byte = byte << (8 - bitCount);
        fputc(byte, outputFile);
    }
    
    free(huffmanCode);

    fclose(inputFile);
    fclose(outputFile);
    
    // Memory cleanup
    free(minHeap->heap);
    free(minHeap);
    freeHuffmanTree(root);
    free(freq);
    
    static char log[256];
	sprintf(log, "%s compressed successfully.\r\nCompressed file saved as %s\r\nTotal bits: %d\r\n", inputFileName, compressedFilePath, totalBits);
	
	return log;
}

DLL_EXPORT char* decompressFile(char* compressedFileName, char* keyFileName) {
    char decompressedFilePath[MAX_FILENAME_LENGTH];
    char dirPath[MAX_FILENAME_LENGTH];
    
	getDirectoryPath(compressedFileName, dirPath);
	sprintf(decompressedFilePath, "%sdecompressed.txt", dirPath);
	
	FILE* compressedFile = fopen(compressedFileName, "rb");
    FILE* keyFile = fopen(keyFileName, "r");
    FILE* outputFile = fopen(decompressedFilePath, "w");

    if (!compressedFile || !keyFile || !outputFile) {
    	static char log[256];
    	strcpy(log, "Error: Couldn't open one of the files.");
        if (compressedFile) fclose(compressedFile);
        if (keyFile) fclose(keyFile);
        if (outputFile) fclose(outputFile);
        return log;
    }

    // Read total bits from key file
    int totalBitsToRead = 0;
    char line[MAX_BITS * 2];
    if (fgets(line, sizeof(line), keyFile) != NULL) {
        if (sscanf(line, "TOTAL_BITS %d", &totalBitsToRead) != 1) {
        	static char log[256];
    		strcpy(log, "Error: Could not read total bits from key file.");
            fclose(compressedFile);
            fclose(keyFile);
            fclose(outputFile);
            return log;
        }
    }

    // Read key file and create character-to-code mapping
    char* codeTable[256] = {0};
    char ch;
    char code[MAX_BITS];
    int freq;
    
    while (fgets(line, sizeof(line), keyFile) != NULL) {
        char charStr[10];
        
        // Try to read character, code, and frequency
        if (sscanf(line, "%s %s %d", charStr, code, &freq) == 3) {
            // Handle special characters
            if (strcmp(charStr, "\\n") == 0) {
                ch = '\n';
            } else if (strcmp(charStr, "SPACE") == 0) {
                ch = ' ';
            } else {
                ch = charStr[0];
            }
            
            // Free previous code if exists
            if (codeTable[(unsigned char)ch]) {
                free(codeTable[(unsigned char)ch]);
            }
            codeTable[(unsigned char)ch] = strdup(code);
        }
    }
    fclose(keyFile);

    // Read compressed file bit by bit
    char tempCode[MAX_BITS] = "";
    int tempLen = 0;
    int byte;
    int bitPos, i;
    int totalBits = 0;
    int charsDecoded = 0;
    
    while ((byte = fgetc(compressedFile)) != EOF && totalBits < totalBitsToRead) {
        // Read bits from MSB to LSB (same as compression)
        for (bitPos = 7; bitPos >= 0; bitPos--) {
            // Stop if we've read enough bits
            if (totalBits >= totalBitsToRead) {
                break;
            }
            
            char bit = (((unsigned char)byte >> bitPos) & 1) ? '1' : '0';
            tempCode[tempLen++] = bit;
            tempCode[tempLen] = '\0';
            totalBits++;
            
            // Check if this code matches any character
            for (i = 0; i < 256; i++) {
                if (codeTable[i] && strcmp(tempCode, codeTable[i]) == 0) {
                    fputc(i, outputFile);
                    tempLen = 0;
                    tempCode[0] = '\0';
                    charsDecoded++;
                    break;
                }
            }
            
            // Safety check: if tempCode gets too long, reset it
            if (tempLen >= MAX_BITS - 1) {
                tempLen = 0;
                tempCode[0] = '\0';
            }
        }
    }

    fclose(outputFile);
    fclose(compressedFile);
    
    // Free allocated memory
    for (i = 0; i < 256; i++) {
        if (codeTable[i]) free(codeTable[i]);
    }

	static char log[256];
	sprintf(log, "%s decompressed successfully.\r\nDecompressed file saved as %s\r\nDecoded %d characters from %d bits.\r\n", compressedFileName, decompressedFilePath, charsDecoded, totalBits);
	
	return log;
}

void getDirectoryPath(char* fullPath, char* dirPath) {
    int len = strlen(fullPath);
    int i;
    for (i = len - 1; i >= 0; i--) {
    	// for both Windows and Unix
        if (fullPath[i] == '\\' || fullPath[i] == '/') {
            break;
        }
    }
    if (i >= 0) {
        strncpy(dirPath, fullPath, i + 1);
        dirPath[i + 1] = '\0';
    } else {
        dirPath[0] = '\0';
    }
}
