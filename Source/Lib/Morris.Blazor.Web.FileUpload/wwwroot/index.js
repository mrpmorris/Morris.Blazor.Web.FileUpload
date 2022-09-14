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

        post: function (formDataId, url, callback) {
            const formData = this._formDataInstances[formDataId];
            return new Promise(function (resolve, reject) {

                const request = new XMLHttpRequest();
                request.open("POST", url);

                request.addEventListener("error", function (e) {
                    console.log('error', e);
                    reject();
                });

                request.addEventListener("load", function (r) {
                    console.log('success', r);
                    resolve();
                });

                request.upload.addEventListener("progress", function (e) {
                    console.log('progress');
                    if (!e.lengthComputable) {
                        return;
                    }
                    callback.invokeMethodAsync("OnProgress", e.loaded, e.total);
                });


                request.send(formData);
            });
        },

        dispose: function (formDataId) {
            delete this._formDataInstances[formDataId];
        }
    }
})();