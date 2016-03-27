interface WordTablePanelProps {
    words: Word[];
}

interface WordTablePanelState {
    edittingWord: Word;
}

class WordTablePanel extends React.Component<WordTablePanelProps, WordTablePanelState> {

    constructor() {
        super();
        this.state = {
            edittingWord: {
                spelling: '',
                chinese: '',
                ukPron: '',
                usPron: ''
            }
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
                <EditWordModal ref="edit" word={this.state.edittingWord} />
            </div>
        );
    }

    private _onRowClick(word: Word) {
        this.setState({
            edittingWord: word
        });
        var editModel = this.refs['edit'] as EditWordModal;
        editModel.show();
    }
}