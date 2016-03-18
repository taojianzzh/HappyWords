interface WordProps extends React.Props<WordItem> {
    word: Word;
}

class WordItem extends React.Component<WordProps, any>{

    render() {
        return <span className="word">
            { this.props.word.spelling }
        </span>;
    }
}