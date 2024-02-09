window.JsFunctions = {
    OpenReport: function (parameters, reportName) {
        var data = { ReportName: reportName, ReportParameters: parameters };
        this._viewerOptions.reportUrl(JSON.stringify(data));
        //alert(JSON.stringify(object));
    },
    _viewerOptions: {
        reportUrl: ko.observable(),
        requestOptions: {
            invokeAction: "/DXXRDV"
        }
    },
    //_designerOptions: {
    //    reportUrl: ko.observable("Report1"), 
    //    requestOptions: { 
    //        getDesignerModelAction: "api/Reporting/getReportDesignerModel"
    //    }
    //},
    InitWebDocumentViewer: function () {
        ko.applyBindings(this._viewerOptions, document.getElementById("viewer"));
    },
    //InitReportDesigner: function () {
    //    ko.applyBindings(this._designerOptions, document.getElementById("designer"));
    //},
    Dispose: function (elementId) {
        var element = document.getElementById(elementId);
        element && ko.cleanNode(element);
    }

}