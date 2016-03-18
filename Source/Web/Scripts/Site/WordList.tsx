class WordList extends React.Component<Array<Word>, any> {
    private _words: Array<Word>;

    constructor(words: Array<Word>) {
        super(words);
        this._words = words;
    }

    render() {
        return <div> {
            $.map(this._words, (word, i) => {
                return <span className="word" key={i}>
                    { word.spelling }
                </span>;
            })
        }
        </div>
    }
}