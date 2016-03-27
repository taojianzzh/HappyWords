interface EditWordModalProps {
    word: Word;
}

class EditWordModal extends React.Component<EditWordModalProps, any> {

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
                                <input type="text" value={this.props.word.spelling}
                                    className="form-control"
                                    placeholder="English spelling..."
                                    ref="spelling" />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">Chinese (optional) </div>
                                <input type="text" value={this.props.word.chinese}
                                    className="form-control"
                                    placeholder="中文..."
                                    ref="chinese" />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">US Pron.</div>
                                <input type="text" value={this.props.word.usPron}
                                    className="form-control"
                                    ref="usPron" />
                            </div>
                            <div className="input-group">
                                <div className="input-group-addon">UK Pron.</div>
                                <input type="text" value={this.props.word.ukPron}
                                    className="form-control"
                                    ref="ukPron" />
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

    show() {
        $('#edit_word_modal').modal();
    }

}