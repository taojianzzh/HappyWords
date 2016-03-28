﻿interface WordTablePanelProps {
    words: Word[];
}

class WordTablePanel extends React.Component<WordTablePanelProps, any> {

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
            </div>
        );
    }

    private _onRowClick(word: Word) {
        
    }

    private _onWordUpdated(word: Word) {

    }

}