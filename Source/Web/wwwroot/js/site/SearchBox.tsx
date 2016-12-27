interface SearchBoxProps extends React.Props<SearchBox> {
    keyword: string;
    onUserInput: any;
}

class SearchBox extends React.Component<SearchBoxProps, any>{

    constructor(props: SearchBoxProps) {
        super(props);
    }

    render() {
        return (
            <div className="row" id="search_box">
                <div className="col-lg-3"></div>
                <div className="col-lg-6">
                    <div className="input-group input-group-lg">
                        <input type="text" className="form-control" id="search_box_input"
                           ref="keyword"
                           onChange={this.handleChange.bind(this) } />
                        <div className="input-group-btn">
                            <button type="button" className="btn btn-default dropdown-toggle" data-toggle="dropdown" aria-haspopup="true" aria-expanded="false">Pron <span className="caret"></span></button>
                            <PronDropdown />
                        </div>
                    </div>
                </div>
                <div className="col-lg-3"></div>
            </div>
        );
    }

    handleChange() {
        this.props.onUserInput((this.refs['keyword'] as HTMLInputElement).value);
    }
}