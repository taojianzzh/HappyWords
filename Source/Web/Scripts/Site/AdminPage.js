var AdminPage = (function () {
    function AdminPage() {
        $(document).ready(function () {
            $('#add_word button').click(function () {
                var spelling = $('#add_word input').val();
                if (spelling) {
                    $.post('/api/word', {
                        spelling: spelling
                    }, function () {
                        alert('your word has been added.');
                    });
                }
            });
        });
    }
    return AdminPage;
})();
