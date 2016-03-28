interface EditWordModalProps {
    onSaved: (word: Word) => any;
    onClosed: () => any;
    word: Word;
}

interface EditWordModalState {
    word: Word;
    saveButtonDisabled: boolean;
}

class EditWordModal extends React.Component<EditWordModalProps, EditWordModalState> {

    constructor() {
        super();
    }

    componentWillMount() {
        this.state = {
            word: this.props.word,
            saveButtonDisabled: true
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
            <div className="modal fade edit-word-modal" ref="modal" tabIndex="-1" role="dialog">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close" onClick={this._handleClose.bind(this)}><span aria-hidden="true">&times; </span></button>
                            <h4 className="modal-title">Edit Word</h4>
                        </div>
                        <div className="modal-body">
                            <div className="input-group">
                                <div className="input-group-addon">Spelling</div>
                                <input type="text" defaultValue={this.props.word.spelling}
                                    className="form-control"
                                    placeholder="English spelling..."
                                    ref="spelling"
                                    contentEditable={false} readOnly={true} />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">Chinese (optional) </div>
                                <input type="text" defaultValue={this.props.word.chinese}
                                    className="form-control"
                                    placeholder="中文..."
                                    ref="chinese"
                                    onChange={this._handleInputChange.bind(this) } />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">US Pron.</div>
                                <input type="text" defaultValue={this.state.word.usPron}
                                    className="form-control"
                                    ref="usPron"
                                    onChange={this._handleInputChange.bind(this) } />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">UK Pron.</div>
                                <input type="text" defaultValue={this.state.word.ukPron}
                                    className="form-control"
                                    ref="ukPron"
                                    onChange={this._handleInputChange.bind(this) } />
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className={saveButtonClassName} onClick={this._saveWord.bind(this) }>Save</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    show() {
        this.state.saveButtonDisabled = true;
        this.setState(this.state);
    }

    private _handleInputChange(event: React.FormEvent) {
        this.state.saveButtonDisabled = false;
        this.setState(this.state);
    }

    private _handleClose() {
        this.props.onClosed && this.props.onClosed();
    }

    private _saveWord() {
        var word = this.state.word;
        $.ajax({
            url: '/api/Word/' + word.spelling,
            method: 'PUT',
            data: word,
            success: (word: Word) => {
                this.props.onSaved && this.props.onSaved(word);
            }
        });
    }
}