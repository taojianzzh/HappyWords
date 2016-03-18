interface WordListProps extends React.Props<WordList> {
    words: Word[];
}

class WordList extends React.Component<WordListProps, any> {

    render() {
        return (
            <div>
                {this.props.words.map((word, i) => {
                    return <WordItem word={word} />
                })}
            </div>
        );
    }
}