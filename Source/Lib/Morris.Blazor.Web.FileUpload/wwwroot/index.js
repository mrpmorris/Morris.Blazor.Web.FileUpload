(function () {
    window.Morris = window.Morris || {};
    window.Morris.Blazor = window.Morris.Blazor || {};
    window.Morris.Blazor.Web = window.Morris.Blazor.Web || {};

    window.Morris.Blazor.Web.MultiFileUploader = {
        _nextNumber: 0,
        _formDataInstances: {},

        create: function () {
            const formData = new FormData();
            const formDataId = this._nextNumber++;
            this._formDataInstances[formDataId] = formData;
            return formDataId;
        },

        addFile: function (formDataId) {
            const formData = this._formDataInstances[formDataId];
            const inputElement = document.querySelector("#theInput");
            const file = inputElement.files[0];
            formData.append("file", file, file.name);
        },

        post: function (formDataId, url) {
            const formData = this._formDataInstances[formDataId];
            const request = new XMLHttpRequest();
            request.open("POST", url);
            request.send(formData);
        },

        dispose: function (formDataId) {
            delete this._formDataInstances[formDataId];
        }
    }
})();