void textType(int key);

void textType(int key){
	if(key >= 'A' && key <= 'Z') {
		printf(">%c : �빮��\n", key);
	} else if (key >= 'a' && key <= 'z') {
		printf(">%c : �ҹ���\n", key);
	} else if (key >= 33 && key <= 47) {	// Ư������(! ~ /)  
		printf(">%c : Ư������\n", key);
	} else if (key >= 33 && key <= 47) {	// Ư������(! ~ /)  
		printf(">%c : Ư������\n", key);
	} else if (key >= 58 && key <= 64) {	// Ư������(: ~ @)  
		printf(">%c : Ư������\n", key);
	} else if (key >= 91 && key <= 96) {	// Ư������([ ~ ')  
		printf(">%c : Ư������\n", key);
	} else if (key >= 123 && key <= 126) {	// Ư������({ ~ ~)  
		printf(">%c : Ư������\n", key);
	}
}
