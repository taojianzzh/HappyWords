interface WordTableProps {
    words: Word[];
    onRowClick: (word: Word) => any;
}

class WordTable extends React.Component<WordTableProps, any>{

    render() {
        var rows = this.props.words.map((w) => {
            return <WordTableRow key={w.spelling} word={w} onClick={this._handleRowClick.bind(this) } />
        });

        return (
            <table id="word_table">
                <tbody>
                    {rows}
                </tbody>
            </table>
        );
    }

    private _handleRowClick(word: Word) {
        this.props.onRowClick && this.props.onRowClick(word);
    }

}