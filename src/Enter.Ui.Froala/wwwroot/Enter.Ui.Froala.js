window.FroalaFunctions = {
    initialize: function () {
        console.log('FroalaFunctions.initialize');
        var link = document.createElement("link");
        link.href = "_content/Enter.UI.Froala2/EnterUi.Froala.min.css";
        link.rel = "stylesheet";
        document.head.appendChild(link);
    },
    create: function (element) {
        new FroalaEditor(element, {
            direction: 'rtl',
            theme:'enter-ui'
        });
    }
};
