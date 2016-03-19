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
            <div className="row" id="search_word">
                <div className="col-lg-3"></div>
                <div className="col-lg-6">
                    <input type="text" className="form-control" id="search_box_input"
                           placeholder="eg. abc, *abc, abc*, *abc*"
                           //value={this.props.keyword}
                           ref="keyword"
                           onChange={this.handleChange.bind(this)}
                    />
                </div>
                <div className="col-lg-3"></div>
            </div>
        );
    }

    handleChange() {
        this.props.onUserInput((this.refs['keyword'] as HTMLInputElement).value);
    }
}