interface WordProps extends React.Props<WordItem> {
    word: Word;
}

class WordItem extends React.Component<WordProps, WordState>{

    constructor(props: WordProps) {
        super(props);
        this.state = {
            hidden: false
        };
    }

    render() {
        return <span className={this.state.hidden ? 'word hidden' : 'word'}>
            { this.props.word.spelling }
        </span>;
    }

    show() {
        this.setState({
            hidden: false
        });
    }

    hide() {
        this.setState({
            hidden: true
        });
    }

    getWordSpelling(): string {
        return this.props.word.spelling;
    }
}