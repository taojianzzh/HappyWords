interface WordListPanelProps {
    words: Word[];
}

class WordListPanel extends React.Component<WordListPanelProps, any> {

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
                    <WordList words={this.props.words} keyword='' />
                </div>
            </div>
        );
    }
}