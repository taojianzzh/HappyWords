interface AdminPageState {
    alert?: AlertModel;
}

class AdminPage extends React.Component<any, AdminPageState> {

    constructor() {
        super();
        this.state = {
            alert: {
                type: AlertType.Hidden
            }
        }
    }

    render() {
        return (
            <div>
                <Alert model={this.state.alert} />
                <WordForm onSuccess={this.onWordAddedSuccess.bind(this)} onError={this.onWordAddedError.bind(this)} />
            </div>
        )
    }

    onWordAddedSuccess(word: Word) {
        this.setState({
            alert: {
                type: AlertType.Success,
                title: 'Success',
                message: 'Your word ' + word.spelling + ' has been added.'
            }
        });
    }

    onWordAddedError(word: Word, title:string, message: string) {
        this.setState({
            alert: {
                type: AlertType.Danger,
                title: title,
                message: message
            }
        });
    }
}