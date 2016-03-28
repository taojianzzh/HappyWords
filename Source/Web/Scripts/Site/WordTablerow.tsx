interface WordTableRowState {
    isEditting: boolean;
}

interface WordTableRowProps {
    word: Word;
    onClick: (word: Word) => any;
}

class WordTableRow extends React.Component<WordTableRowProps, WordTableRowState> {

    constructor() {
        super();
        this.state = {
            isEditting: false
        };
    }

    render() {
        var word = this.props.word;
        if (this.state.isEditting) {
            return (
                <tr>
                    <td>
                        {word.spelling}
                    </td>
                    <td>
                        {word.usPron}
                    </td>
                    <td>
                        {word.chinese}
                    </td>
                    <td>
                        <EditWordModal word={this.props.word}
                            onSaved={this._onEditModalSaved.bind(this)}
                            onClosed={this._onEditModalClosed.bind(this)} />
                    </td>
                </tr>
            );
        } else {
            return (
                <tr onClick={this._handleClick.bind(this) }>
                    <td>
                        {word.spelling}
                    </td>
                    <td>
                        {word.usPron}
                    </td>
                    <td>
                        {word.chinese}
                    </td>
                    <td>
                    </td>
                </tr>
            );
        }
    }

    private _handleClick() {
        this.setState({
            isEditting: true
        });
    }

    private _onEditModalSaved() {
        this.setState({
            isEditting: false
        });
    }

    private _onEditModalClosed() {
        this.setState({
            isEditting: false
        });
    }
}