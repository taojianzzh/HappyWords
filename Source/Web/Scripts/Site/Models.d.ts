﻿interface Word {
    spelling: string;
    chinese: string;
    ukPron: string;
    usPron: string;
}

interface AddWordRequest {
    spelling: string;
    chinese: string;
}