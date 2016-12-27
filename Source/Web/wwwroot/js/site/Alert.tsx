enum AlertType {
    Success,
    Info,
    Warning,
    Danger,
    Hidden
}

interface AlertModel {
    type: AlertType;
    title?: string;
    message?: string;
}

interface AlertProps {
    model: AlertModel;
}

class Alert extends React.Component<AlertProps, any> {

    render() {
        var className = 'alert alert-' + AlertType[this.props.model.type].toString().toLowerCase();
        if (this.props.model.type == AlertType.Hidden) {
            return <div />
        }
        return (
            <div className={className} role="alert">
                <strong>{this.props.model.title}:</strong> {this.props.model.message}
            </div>
        );
    }

}