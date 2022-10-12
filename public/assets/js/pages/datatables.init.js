/*
Template Name: Minia - Admin & Dashboard Template
Author: Themesbrand
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: Datatables Js File
*/

$(document).ready(function() {
    $('#datatable').DataTable();

    //Buttons examples
    var table = $('#datatable-buttonspasien').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });

    table.buttons().container()
        .appendTo('#datatable-buttonspasien_wrapper .col-md-6:eq(0)');

    $(".dataTables_length select").addClass('form-select form-select-sm');
    
});

$(document).ready(function() {
    $('#datatable').DataTable();

    //Buttons examples

    var table = $('#datatable-buttonsgejala').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });

        table.buttons().container()
        .appendTo('#datatable-buttonsgejala_wrapper .col-md-6:eq(0)');

    $(".dataTables_length select").addClass('form-select form-select-sm');
    
});

$(document).ready(function() {
    $('#datatable').DataTable();

    //Buttons examples
    
    var table = $('#datatable-buttonspengetahuan').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });

        table.buttons().container()
        .appendTo('#datatable-buttonspengetahuan_wrapper .col-md-6:eq(0)');


    $(".dataTables_length select").addClass('form-select form-select-sm');
    
});

$(document).ready(function() {
    $('#datatable').DataTable();

    //Buttons examples
    var table = $('#datatable-buttonspenyakit').DataTable({
        lengthChange: false,
        buttons: ['copy', 'excel', 'pdf', 'colvis']
    });

        table.buttons().container()
        .appendTo('#datatable-buttonspenyakit_wrapper .col-md-6:eq(0)');

    $(".dataTables_length select").addClass('form-select form-select-sm');
    
});
