interface WordTablePanelProps {
    words: Word[];
}

class WordTablePanel extends React.Component<WordTablePanelProps, WordTablePanelState> {

    constructor() {
        super();
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
                <EditWordModal ref="edit" />
            </div>
        );
    }

    private _onRowClick(word: Word) {
        var editModel = this.refs['edit'] as EditWordModal;
        editModel.show(word);
    }

}