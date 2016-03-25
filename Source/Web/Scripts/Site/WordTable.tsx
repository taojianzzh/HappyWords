interface WordTableProps {
    words: Word[];
}

class WordTable extends React.Component<WordTableProps, any>{

    render() {
        var rows = this.props.words.map((w) => {
            return (
                <tr key={w.spelling}>
                    <td>
                        {w.spelling}
                    </td>
                    <td>
                        {w.usPron}
                    </td>
                    <td>
                        {w.chinese}
                    </td>
                </tr>
            );
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