interface WordTableRowState {
    isEditting: boolean;
}

interface WordTableRowProps {
    word: Word;
}

class WordTableRow extends React.Component<WordTableRowProps, WordTableRowState> {

    constructor() {
        super();
        this.state = {
            isEditting: false
        };
    }

    render() {
        if (this.state.isEditting) {
            return (
                <tr>
                    <td>
                        {this.props.word.spelling}
                    </td>
                    <td>
                        {this.props.word.usPron}
                    </td>
                    <td>
                        {this.props.word.chinese}
                    </td>
                    <td>
                        <EditWordModal word={this.props.word}
                            onSaved={this._onEditModalSaved.bind(this)}
                            onClosed={this._onEditModalClosed.bind(this)} />
                    </td>
                </tr>
            )
        } else {
            return (
                <tr onClick={this._handleClick.bind(this)}>
                    <td>
                        {this.props.word.spelling}
                    </td>
                    <td>
                        {this.props.word.usPron}
                    </td>
                    <td>
                        {this.props.word.chinese}
                    </td>
                    <td>
                    </td>
                </tr>
            )
        }
    }

    private _handleClick() {
        this.setState({
            isEditting: true
        });
    }

    private _onEditModalSaved(word: Word) {
        this.props.word.chinese = word.chinese;
        this.props.word.usPron = word.usPron;
        this.props.word.ukPron = word.ukPron;
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