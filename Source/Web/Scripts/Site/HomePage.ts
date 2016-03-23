class HomePage {

    constructor() {
        $(document).ready(() => {
            this._LoadWords();
        });
    }

    private _LoadWords() {
        $.get('/api/word?take=80', (words: Word[]) => {
            
        });
    }
}