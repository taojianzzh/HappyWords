class HomePage {
    constructor() {
        $(document).ready(() => {
            this._LoadWords();
        });
    }

    private _LoadWords() {
        $.get('/api/word', (words: Word[]) => {
            ReactDOM.render(React.createElement(WordList, { words: words }), document.getElementById('word_list'));
        });
    }
}