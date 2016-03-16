class HomePage {
    constructor() {
        $(document).ready(() => {
            this._LoadWords();
        });
    }

    private _LoadWords() {
        var wordList = $('#word_list');
        $.get('/api/word', (words) => {
            $.each(words, (i, word) => {
                wordList.append($('<span class="label label-primary word"></span>').text(word.spelling));
            });
        });
    }
}