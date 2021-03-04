void textType(int key);

void textType(int key){
	if(key >= 'A' && key <= 'Z') {
		printf(">%c : 대문자\n", key);
	} else if (key >= 'a' && key <= 'z') {
		printf(">%c : 소문자\n", key);
	} else if (key >= 33 && key <= 47) {	// 특수문자(! ~ /)  
		printf(">%c : 특수문자\n", key);
	} else if (key >= 33 && key <= 47) {	// 특수문자(! ~ /)  
		printf(">%c : 특수문자\n", key);
	} else if (key >= 58 && key <= 64) {	// 특수문자(: ~ @)  
		printf(">%c : 특수문자\n", key);
	} else if (key >= 91 && key <= 96) {	// 특수문자([ ~ ')  
		printf(">%c : 특수문자\n", key);
	} else if (key >= 123 && key <= 126) {	// 특수문자({ ~ ~)  
		printf(">%c : 특수문자\n", key);
	}
}
