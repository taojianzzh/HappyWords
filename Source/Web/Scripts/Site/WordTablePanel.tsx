interface WordTablePanelProps {
    words: Word[];
}

interface WordTablePanelState {
    isEdittingWord: boolean;
}

class WordTablePanel extends React.Component<WordTablePanelProps, WordTablePanelState> {

    private _edittingWord: Word;

    constructor() {
        super();
        this.state = {
            isEdittingWord: false
        }
    }

    render() {
        return (
            <div className="panel panel-default">
                <div className="panel-heading">
                    <h3 className="panel-title">All Words</h3>
                </div>
                <div className="panel-body">
                    <WordTable words={this.props.words} onRowClick={this._onRowClick.bind(this)} />
                </div>
                <EditWordModal ref="edit" isEditting={this.state.isEdittingWord} getEdittingWord={this._getEdittingWord.bind(this) } />
            </div>
        );
    }

    private _onRowClick(word: Word) {
        
        this._edittingWord = word;
        this.setState({
            isEdittingWord: true
        });

        var editModel = this.refs['edit'] as EditWordModal;
        editModel.show();
    }

    private _getEdittingWord() {
        return this._edittingWord;
    }
}