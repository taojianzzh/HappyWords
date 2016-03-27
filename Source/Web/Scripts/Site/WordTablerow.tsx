interface WordTableRowProps {
    word: Word;
    onClick: (word: Word) => any;
}

class WordTableRow extends React.Component<WordTableRowProps, any> {

    render() {
        var word = this.props.word;
        return (
            <tr onClick={this._handleClick.bind(this)}>
                <td>
                    {word.spelling}
                </td>
                <td>
                    {word.usPron}
                </td>
                <td>
                    {word.chinese}
                </td>
            </tr>
        );
    }

    private _handleClick() {
        this.props.onClick && this.props.onClick(this.props.word);
    }
}