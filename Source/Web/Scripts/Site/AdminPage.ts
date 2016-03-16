class AdminPage {
    constructor() {
        $(document).ready(() => {
            $('#add_word button').click(() => {
                var spelling = $('#add_word input').val();
                if (spelling) {
                    $.post('/api/word', {
                        spelling: spelling
                    }, () => {
                        alert('your word has been added.');
                    });
                }
            });
        });
    }
}