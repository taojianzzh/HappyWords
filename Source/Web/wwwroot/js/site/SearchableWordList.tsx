interface SearchableWordListProps extends React.Props<WordList> {
    words: Word[];
}

interface SearchableWordListState {
    keyword: string;
}

class SearchableWordList extends React.Component<SearchableWordListProps, SearchableWordListState> {

    constructor() {
        super();
        this.state = {
            keyword: ''
        };
    }

    render() {
        return (
            <div>
                <SearchBox keyword = '' onUserInput={this.handleUserInput.bind(this)} />
                <WordList words={this.props.words} keyword={this.state.keyword} />
            </div>
        );
    }

    handleUserInput(keyword: string) {
        this.setState({
            keyword: keyword
        });
    }
}
