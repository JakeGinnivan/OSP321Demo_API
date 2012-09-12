var RowViewModel = function (date, hours, engagement) {
    var self = this;

    self.date = date;
    self.hours = hours;
    self.engagement = engagement.Client;
    self.isSubmitting = ko.observable(false);
};

var ViewModel = function () {
    var self = this;
    self.hourOptions = [1, 2, 3, 4, 5, 6, 7, 8];

    self.search = function () {
        $.getJSON("https://readifytimesheetsapi.azurewebsites.net/api/consultants/me/timesheets?outstanding=true",
        function (data) {
            var mapped = $.map(data, function (item) {
                return new RowViewModel(item.Date, item.Hours, item.Engagement);
            });
            $("#resultsTable").show();
            self.results(mapped);
            $("#fetchingLabel").hide();
        });
    };

    self.submit = function (item) {
        $("#submitButton").prop("disabled", true);
        item.isSubmitting(true);
        setTimeout(function () {
            self.results.remove(item);
        }, 1000);
    };

    this.results = ko.observableArray();
    self.search();
};


$(function () {
    var vm = new ViewModel();

    ko.bindingHandlers.dateString = {
        update: function (element, valueAccessor) {
            var value = valueAccessor();
            var valueUnwrapped = ko.utils.unwrapObservable(value);
            var dateString = new Date(valueUnwrapped).toDateString();
            $(element).text(dateString);
        }
    };

    ko.applyBindings(vm);
});

//// Add any initialization logic to this function
Office.initialize = function () {

};
