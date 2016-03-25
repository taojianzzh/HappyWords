interface WordFormProps {
    onSuccess: (word: Word) => any;
    onError: (word: Word, title: string, message: string) => any
}

class WordForm extends React.Component<WordFormProps, any> {

    render() {
        return (
            <div id="add_word">
                <div className="row">
                    <div className="col-md-6 col-lg-6">
                        <div className="input-group">
                            <div className="input-group-addon">Spelling</div>
                            <input type="text"
                                className="form-control"
                                placeholder="English spelling..."
                                ref="spelling"
                                onKeyPress={this.handleKeyPress.bind(this)}/>
                        </div>
                    </div>
                    <div className="col-md-6 col-lg-6">
                        <div className="input-group">
                            <div className="input-group-addon">Chinese</div>
                            <input type="text"
                                className="form-control"
                                placeholder="中文..."
                                ref="chinese"
                                onKeyPress={this.handleKeyPress.bind(this)} />
                        </div>
                    </div>
                </div>
                <div className="row">
                    <div className="col-md-12  col-lg-12">
                        <button className="btn btn-primary" type="button" onClick={this.handleButtonClick.bind(this)}>Add</button>
                    </div>
                </div>
            </div>
        );
    }

    handleKeyPress(e: KeyboardEvent) {
        if (e.key === 'Enter') {
            this.handleButtonClick();
        }
    }

    handleButtonClick() {
        var word: Word = {
            spelling: (this.refs['spelling'] as HTMLInputElement).value,
            chinese: (this.refs['chinese'] as HTMLInputElement).value
        };
        if (word.spelling) {
            $.ajax({
                method: 'POST',
                url: '/api/word',
                data: word,
                success: () => {
                    this.props.onSuccess(word);
                    (this.refs['spelling'] as HTMLInputElement).value = '';
                    (this.refs['spelling'] as HTMLInputElement).focus();
                    (this.refs['chinese'] as HTMLInputElement).value = '';
                },
                error: (xhr, textStatus, errorThrown) => {
                    this.props.onError(word, errorThrown, JSON.parse(xhr.responseText).message);
                }
            });
        }
    }
}