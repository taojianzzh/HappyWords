interface WordTableProps {
    words: Word[];
}

class WordTable extends React.Component<WordTableProps, any>{

    render() {
        var rows = this.props.words.map((w) => {
            return <WordTableRow key={w.spelling} word={w} />
        });

        return (
            <table id="word_table">
                <tbody>
                    {rows}
                </tbody>
            </table>
        );
    }
}