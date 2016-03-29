interface EditWordModalProps {
    onSaved: (word: Word) => any;
    onClosed: () => any;
    word: Word;
}

interface EditWordModalState {
    saveButtonDisabled: boolean;
    edittingWord: Word;
}

class EditWordModal extends React.Component<EditWordModalProps, EditWordModalState> {

    constructor() {
        super();
    }

    componentWillMount() {
        this.state = {
            saveButtonDisabled: true,
            edittingWord: {
                spelling: this.props.word.spelling,
                chinese: this.props.word.chinese,
                usPron: this.props.word.usPron,
                ukPron: this.props.word.ukPron
            }
        };
    }

    componentDidMount() {
        $((this.refs['modal'] as HTMLElement)).modal();
    }

    render() {

        var saveButtonClassName = 'btn btn-primary';
        if (this.state.saveButtonDisabled) {
            saveButtonClassName += ' disabled';
        }
        return (
            <div className="modal fade edit-word-modal" ref="modal" tabIndex="-1" role="dialog" data-backdrop="static" data-keyboard="false">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={this._handleClose.bind(this)}><span aria-hidden="true">&times; </span></button>
                            <h4 className="modal-title">Edit Word</h4>
                        </div>
                        <div className="modal-body">
                            <div className="input-group">
                                <div className="input-group-addon">Spelling</div>
                                <input type="text" value={this.state.edittingWord.spelling}
                                    className="form-control"
                                    ref="spelling"
                                    contentEditable={false} readOnly={true} />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">Chinese (optional) </div>
                                <input type="text" value={this.state.edittingWord.chinese}
                                    className="form-control"
                                    ref="chinese"
                                    onChange={this._handleChineseChange.bind(this) } />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">US Pron.</div>
                                <input type="text" value={this.state.edittingWord.usPron}
                                    className="form-control"
                                    ref="usPron"
                                    onChange={this._handleUsPronChange.bind(this) } />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">UK Pron.</div>
                                <input type="text" value={this.state.edittingWord.ukPron}
                                    className="form-control"
                                    ref="ukPron"
                                    onChange={this._handleUkPronChange.bind(this) } />
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-default pull-left"
                                onClick={ this._clear.bind(this) }>Clear</button>
                            <button type="button" className="btn btn-default pull-left"
                                onClick={ this._sync.bind(this) }>Sync from Bing Dict</button>
                            <button type="button" className={saveButtonClassName}
                                onClick={ this._saveWord.bind(this) }
                                data-dismiss="modal"
                                disabled={this.state.saveButtonDisabled}>Save</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    private _handleChineseChange(event: React.FormEvent) {
        this.state.saveButtonDisabled = false;
        this.state.edittingWord.chinese = (event.target as HTMLInputElement).value;
        this.setState(this.state);
    }

    private _handleUsPronChange(event: React.FormEvent) {
        this.state.saveButtonDisabled = false;
        this.state.edittingWord.usPron = (event.target as HTMLInputElement).value;
        this.setState(this.state);
    }

    private _handleUkPronChange(event: React.FormEvent) {
        this.state.saveButtonDisabled = false;
        this.state.edittingWord.ukPron = (event.target as HTMLInputElement).value;
        this.setState(this.state);
    }

    private _handleClose() {
        this.props.onClosed && this.props.onClosed();
    }

    private _saveWord() {
        $.ajax({
            url: '/api/Word/' + this.state.edittingWord.spelling,
            method: 'PUT',
            data: this.state.edittingWord,
            success: (word: Word) => {
                this.props.onSaved && this.props.onSaved(word);
            }
        });
    }

    private _clear() {
        this._updateState('', '', '', true);
    }

    private _sync() {
        $.get('/api/bing/' + this.props.word.spelling, (bingDictWord: BingDictWord) => {
            this._updateState(bingDictWord.chinese, bingDictWord.pron.us, bingDictWord.pron.uk);
        });
    }

    private _updateState(chinese: string, usPron: string, ukPron: string, force: boolean = false) {
        this.state.saveButtonDisabled = false;
        this.state.edittingWord.chinese = (force ? chinese : (this.state.edittingWord.chinese || chinese));
        this.state.edittingWord.usPron = (force ? usPron : (this.state.edittingWord.usPron || usPron));
        this.state.edittingWord.ukPron = (force ? ukPron : (this.state.edittingWord.ukPron || ukPron));
        this.setState(this.state);
    }
}