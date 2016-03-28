interface EditWordModalState {
    word: Word;
}

class EditWordModal extends React.Component<any, EditWordModalState> {

    constructor() {
        super();
        this.state = {
            word: {
                spelling: '', chinese: '', ukPron: '', usPron: ''
            }
        }
    }

    render() {

        return (
            <div className="modal fade" id="edit_word_modal" tabIndex="-1" role="dialog">
                <div className="modal-dialog" role="document">
                    <div className="modal-content">
                        <div className="modal-header">
                            <button type="button" className="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times; </span></button>
                            <h4 className="modal-title">Edit Word</h4>
                        </div>
                        <div className="modal-body">
                            <div className="input-group">
                                <div className="input-group-addon">Spelling</div>
                                <input type="text" value={this.state.word.spelling}
                                    className="form-control"
                                    placeholder="English spelling..."
                                    ref="spelling"
                                    contentEditable={false} />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">Chinese (optional) </div>
                                <input type="text" value={this.state.word.chinese}
                                    className="form-control"
                                    placeholder="中文..."
                                    ref="chinese"
                                    onChange={this._handleChineseChange.bind(this)} />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">US Pron.</div>
                                <input type="text" value={this.state.word.usPron}
                                    className="form-control"
                                    ref="usPron"
                                    onChange={this._handleUsPronChange.bind(this)} />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">UK Pron.</div>
                                <input type="text" value={this.state.word.ukPron}
                                    className="form-control"
                                    ref="ukPron"
                                    onChange={this._handleUkPronChange.bind(this)} />
                            </div>
                        </div>
                        <div className="modal-footer">
                            <button type="button" className="btn btn-primary">Save</button>
                        </div>
                    </div>
                </div>
            </div>
        )
    }

    show(word: Word) {
        this.state.word.spelling = word.spelling;
        this.state.word.chinese = word.chinese;
        this.state.word.usPron = word.usPron;
        this.state.word.ukPron = word.ukPron;

        this.setState(this.state);

        $('#edit_word_modal').modal();
    }

    private _handleChineseChange(event: React.FormEvent) {
        this.state.word.chinese = (event.target as HTMLInputElement).value;
        this.setState(this.state);
    }

    private _handleUsPronChange(event: React.FormEvent) {
        this.state.word.usPron = (event.target as HTMLInputElement).value;
        this.setState(this.state);
    }

    private _handleUkPronChange(event: React.FormEvent) {
        this.state.word.ukPron = (event.target as HTMLInputElement).value;
        this.setState(this.state);
    }
}