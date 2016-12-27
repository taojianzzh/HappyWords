interface AddWordPanelProps {
    onWordAdded: (word: Word) => any;
}

interface AddWordPanelState {
    alert?: AlertModel;
}

class AddWordPanel extends React.Component<AddWordPanelProps, AddWordPanelState> {

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
            <div className="panel panel-default">
                <div className="panel-heading">
                    <h3 className="panel-title">Add Words</h3>
                </div>
                <div className="panel-body">
                    <Alert model={this.state.alert} />
                    <WordForm onSuccess={this.onWordAddedSuccess.bind(this) } onError={this.onWordAddedError.bind(this) } />
                </div>
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

        this.props.onWordAdded && this.props.onWordAdded(word);
    }

    onWordAddedError(word: AddWordRequest, title: string, message: string) {
        this.setState({
            alert: {
                type: AlertType.Danger,
                title: title,
                message: message
            }
        });
    }
}