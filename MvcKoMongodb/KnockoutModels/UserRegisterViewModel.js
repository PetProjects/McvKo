var userRegisterViewModel;

function User(id, firstName, lastName, age, description, gender) {
    var self = this;

    // observable are update elements upon changes, also update on element data changes [two way binding]
    self.Id = ko.observable(id);
    self.FirstName = ko.observable(firstName);
    self.LastName = ko.observable(lastName);

    // create computed field by combining first name and last name
    self.FullName = ko.computed(function () {
        return self.FirstName() + " " + self.LastName();
    }, self);

    self.Age = ko.observable(age);
    self.Description = ko.observable(description);
    self.Gender = ko.observable(gender);

    // Non-editable catalog data - should come from the server
    self.genders = [
        "Male",
        "Female",
        "Other"
    ];

    self.addUser = function () {
        var dataObject = ko.toJSON(this);

        // remove computed field from JSON data which server is not expecting
        delete dataObject.FullName;

        $.ajax({
            url: '/api/user',
            type: 'post',
            data: dataObject,
            contentType: 'application/json',
            success: function (data) {
                userRegisterViewModel.userListViewModel.users.push(new User(data.Id, data.FirstName, data.LastName, data.Age, data.Description, data.Gender));

                self.Id(null);
                self.FirstName('');
                self.LastName('');
                self.Age('');
                self.Description('');
            }
        });
    };
}

function UserList() {

    var self = this;

    // observable arrays are update binding elements upon array changes
    self.users = ko.observableArray([]);

    self.getUsers = function () {
        self.users.removeAll();

        $.getJSON('/api/user', function (data) {
            $.each(data, function (key, value) {
                self.users.push(new User(value.Id, value.FirstName, value.LastName, value.Age, value.Description, value.Gender));
            });
        });
    };


    self.removeUser = function (user) {
        $.ajax({
            url: '/api/user/' + user.Id(),
            type: 'delete',
            contentType: 'application/json',
            success: function () {
                self.users.remove(user);
            }
        });
    };
}


// create index view view model which contain two models for partial views
userRegisterViewModel = { addUserViewModel: new User(), userListViewModel: new UserList() };


// on document ready
$(document).ready(function () {

    // bind view model to referring view
    ko.applyBindings(userRegisterViewModel);

    userRegisterViewModel.userListViewModel.getUsers();
});