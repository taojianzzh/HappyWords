interface AdminPageState {
    words: Word[];
}

class AdminPage extends React.Component<any, AdminPageState> {

    constructor() {
        super();
        this.state = {
            words: []
        }
    }

    componentDidMount() {
        $.get('/api/word', (words: Word[]) => {
            this.setState({
                words: words
            });
        });
    }

    render() {
        return (
            <div>
                <AddWordPanel onWordAdded={this._handleWordAdded.bind(this) } />
                <WordListPanel words={this.state.words} />
            </div>
        )
    }

    private _handleWordAdded(word: Word) {
        var words = [word].concat(this.state.words);
        this.setState({
            words: words
        });
    }
}