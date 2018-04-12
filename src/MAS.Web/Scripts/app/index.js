$(function () {
    $("#get-employees").on("click", function () {
        loadEmployees();
        return false;
    });
});

let loadEmployees = function () {
    $("#table-body").html("");
    const employeeId = $("#employee-id").val();
    if (employeeId === "") {
        employee.getAll(function(data) {
            if (data != null) {
                let rows = "";
                for (let i = 0; i < data.length; i++) {
                    rows += buildRow(data[i]);
                }
                $("#table-body").html(rows);
            }
        });
    } else {
        if (!isNaN(employeeId)) {
            employee.getById(function(data) {
                if (data != null)
                    $("#table-body").html(buildRow(data));
                },
                employeeId);
        } else {
            alert("The employee id must be a number");
        }
    }
}

var buildRow = function (rowData) {
    return `<tr><td>${rowData.name}</td><td>${rowData.roleName}</td><td>${rowData.contractTypeName}</td><td>${formatNumber(rowData.hourlySalary)}</td><td>${formatNumber(rowData.monthlySalary)}</td><td>${formatNumber(rowData.anualSalary)}</td></tr>`;
}

var formatNumber = function (number) {
    number += '';
    x = number.split('.');
    x1 = x[0];
    x2 = x.length > 1 ? '.' + x[1] : '';
    var rgx = /(\d+)(\d{3})/;
    while (rgx.test(x1)) {
        x1 = x1.replace(rgx, '$1' + ',' + '$2');
    }
    return "$ " + (x1 + x2);
}