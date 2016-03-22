interface WordFormProps {
    onSuccess: (word: Word) => any;
    onError: (word: Word, title: string, message: string) => any
}

class WordForm extends React.Component<WordFormProps, any> {

    render() {
        return (
            <div className="input-group" id="add_word">
                <input type="text"
                    className="form-control"
                    placeholder="Type word..."
                    ref="spelling"
                    onKeyPress={this.handleKeyPress.bind(this)} />
                <span className="input-group-btn">
                    <button className="btn btn-primary" type="button" onClick={this.handleButtonClick.bind(this)}>Add</button>
                </span>
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
            spelling: (this.refs['spelling'] as HTMLInputElement).value
        };
        if (word.spelling) {
            $.ajax({
                method: 'POST',
                url: '/api/word',
                data: word,
                success: () => {
                    this.props.onSuccess(word);
                    (this.refs['spelling'] as HTMLInputElement).value = '';
                },
                error: (xhr, textStatus, errorThrown) => {
                    this.props.onError(word, errorThrown, JSON.parse(xhr.responseText).message);
                }
            });
        }
    }
}