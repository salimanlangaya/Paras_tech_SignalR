/// <reference path="../lib/signalr/browser/signalr.js" />
// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(() => {
    let connection = new signalR.HubConnectionBuilder().withUrl("/signalServer").build();

    connection.start();

    connection.on("refreshMachine", function () {
        loadData();
    });

    loadData();

    function loadData() {
        var tr = '';
        debugger
        $.ajax({
            url: '/Machine/GetMachines',
            method: 'GET',
            success: (result) => {
                $.each(result, (k, v) => {
                    
                    tr = tr + `<tr>
                        <td>${v.machineName}</td>
                        <td>${v.status}</td>                        
                    </tr>`;
                    
                });

                $("#tableBody").html(tr);
            },
            error: (error) => {
                console.log(error);
            }
        });
    }
});