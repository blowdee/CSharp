$(document).ready(function () {
    (function () {
        $("input").keyup(function () {

            var empty = false;
            $("input").each(function () {
                if ($(this).val() == '') {
                    empty = true;
                }
            });

            if (empty) {
                $("#submit").attr("disabled", "disabled");
            } else {
                $("#submit").removeAttr("disabled");
            }
        });
    })()

    $("#submit").click(function () {
        $("#playersForm").hide();
        $("#player1").html($("#name1").val() + "(X)");
        $("#player2").html($("#name2").val() + "(O)");
        $("#board").css("visibility", "visible");
    })
});

var turn = 1;
var gameOver = false;

$(document).ready(function () {
    $("td").click(function () {
        if (this.innerHTML === "" && !gameOver) {
            if (turn % 2 === 1) {
                this.innerHTML = 'X';
            }
            else {
                this.innerHTML = 'O';
            }
            $.ajax({
                type: "POST",
                url: "Home/Move",
                data: {
                    player: turn,
                    position: $(this).attr("id")
                },
                success: function (data) {
                    $.ajax({
                        type: "GET",
                        url: "Home/CheckStatus",
                        success: function (res) {
                            var array = JSON.parse(res);
                            if (array[0] === true) {
                                gameOver = true;
                                if (array[1] === true) {
                                    alert("Draw!");
                                }
                                else {
                                    alert("Player " + $("#player" + turn).html() + " won!");
                                }
                                $("#againBtn").css("visibility", "visible");
                            }
                            else {
                                turn = (turn === 1 ? 2 : 1);
                            }
                        }
                    })
                }
            });
        }
        else {
            alert("Choose another cell");
        }
    })
})

function newGame() {
    $.ajax({
        type: "POST",
        url: "Home/PlayAgain"
    })
    $("td").each(function () {
        this.innerHTML = '';
    })
    turn = 1;
    gameOver = false;
    $("#againBtn").css("visibility", "hidden");
}