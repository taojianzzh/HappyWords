class SearchPage {
    constructor() {
        $(document).ready(() => {
            this._LoadWords();
        });
    }

    private _LoadWords() {
        $.get('/api/word', (words: Word[]) => {
            ReactDOM.render(React.createElement(SearchableWordList, { words: words }), document.getElementById('search_page'));
        });
    }
}