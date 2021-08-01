window.addEventListener("load", function () {
    events();
})

function events() {
    load();

    function load() {
        fetch({
            type: "GET",
            url: "/frontend/Users",
            callback: (response) => {
                console.log(response);
                if (response.result) {
                    $.each(response.users, function (key, item) {
                        var name = item.First_name + " " + item.Last_name;
                        switch (document.title) {
                            case "Deposit":
                                $(".section-deposit .users").append("<option value=" + item.Id + " data-country='" + item.Country + "' data-balance='" + item.Balance + "'>" + name + "</option>");
                            case "Withdraw":
                                $(".section-withdraw .users").append("<option value=" + item.Id + " data-country='" + item.Country + "' data-balance='" + item.Balance + "'>" + name + "</option>");
                        }
                    })
                }
            }
        })
    }

    $(".section-deposit form").on("submit", function (event) {
        event.preventDefault();

        const amount = $(".section-deposit form input[name='amount']").val();
        const user = $(".section-deposit form select[name='users']").val();

        const has_amount = amount !== "";
        const has_user = user !== "";
        const is_amount_bigger_than_zero = amount > 0;

        let submit = true;
        let alert_text = "";

        if (!is_amount_bigger_than_zero) {
            submit = false;
            alert_text = "Your deposit amount should be bigger than zero.";
        }

        if (!has_amount || !has_user) {
            submit = false;
            alert_text = "Please fill empty fields.";
        }

        if (submit) {
            fetch({
                dataType: "json",
                url: "/frontend/deposit/",
                type: "POST",
                data: {
                    user_id: user,
                    amount: amount
                },
                callback: (response) => {
                    if (response.result) {
                        $(".section-deposit .users").find(":selected").removeAttr("data-balance");
                        $(".section-deposit .users").find(":selected").attr("data-balance", response.Balance);
                        $(".section-deposit .balance").html("$" + response.Balance);
                        $(".section-deposit form input[name='amount']").val("");
                    }

                    new Notification({
                        type: "Alert",
                        title: "Deposit",
                        content: response.message,
                        button_text: "Okay"
                    }).show();
                }
            })
        } else {
            new Notification({
                type: "Alert",
                title: "Deposit",
                content: alert_text,
                button_text: "Okay"
            }).show();
        }
    })

    $(".section-deposit .users").unbind().on("change", function (event) {
        var balance = $(this).find(":selected").attr("data-balance");
        var country = $(this).find(":selected").attr("data-country");

        $(".section-deposit .country").html(country ? country : "-");
        $(".section-deposit .balance").html(balance ? "$" + balance : "-");
    });

    $(".section-withdraw form").on("submit", function (event) {
        event.preventDefault();

        const amount = $(".section-withdraw form input[name='amount']").val();
        const user = $(".section-withdraw form select[name='users']").val();

        const has_amount = amount !== "";
        const has_user = user !== "";
        const is_amount_bigger_than_zero = amount > 0;

        let submit = true;
        let alert_text = "";

        if (!is_amount_bigger_than_zero) {
            submit = false;
            alert_text = "Your withdraw amount should be bigger than zero.";
        }

        if (!has_amount || !has_user) {
            submit = false;
            alert_text = "Please fill empty fields.";
        }

        if (submit) {
            fetch({
                dataType: "json",
                url: "/frontend/withdraw/",
                type: "POST",
                data: {
                    user_id: user,
                    amount: amount
                },
                callback: (response) => {
                    if (response.result) {
                        $(".section-withdraw .users").find(":selected").removeAttr("data-balance");
                        $(".section-withdraw .users").find(":selected").attr("data-balance", response.Balance);
                        $(".section-withdraw .balance").html("$" + response.Balance);
                        $(".section-withdraw form input[name='amount']").val("");
                    }

                    new Notification({
                        type: "Alert",
                        title: "Withdraw",
                        content: response.message,
                        button_text: "Okay"
                    }).show();
                }
            })
        } else {
            new Notification({
                type: "Alert",
                title: "Withdraw",
                content: alert_text,
                button_text: "Okay"
            }).show();
        }
    })

    $(".section-withdraw .users").unbind().on("change", function (event) {
        var balance = $(this).find(":selected").attr("data-balance");
        var country = $(this).find(":selected").attr("data-country");

        $(".section-withdraw .country").html(country ? country : "-");
        $(".section-withdraw .balance").html(balance ? "$" + balance : "-");
    });
}

function fetch(config) {
    $.ajax({
        dataType: config.dataType ? config.dataType : "json",
        type: config.type,
        url: config.url,
        data: config.data,
        success: function (response) {
            config.callback(response);
        }
    });
}

function Notification(config) {
    let _this = this;
    let _proto = Notification.prototype;

    this.types = {
        Alert
    }

    _proto.show = () => {
        new _this.types[config.type]().show(config)
    }
}

function Alert() {
    let _this = this;
    let _proto = Alert.prototype;

    _proto.set = (config) => {
        _proto.reset();

        const element = $(".alert");

        element.find(".content > .header > h2").html(config.title);
        element.find(".content > .body").html(config.content);
        element.find(".content > .footer > button").html(config.button_text);

        element.addClass("open");
    }

    _proto.reset = function () {
        const element = $(".alert");

        element.find(".content > .header > h2").html("");
        element.find(".content > .body").html("");
        element.find(".content > .footer > button").html("");
    }

    _proto.show = (config) => {
        _this.set(config);

        $(".alert").addClass("open");

        events();
    }

    _proto.hide = () => {
        _proto.reset();

        $(".alert").removeClass("open");
    }

    function events() {
        $(".alert .close").unbind("click").click(function () {
            _this.hide();
        })

        $(".alert").unbind("click").click("click", function (e) {
            const is_wrapper = e.target.classList.contains("alert");

            if (is_wrapper) {
                _this.hide();
            }
        })
    }
}