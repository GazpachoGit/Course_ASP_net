// function createItem(item) {
//     return `<div class="col">
//                     <div class="card text-center">
//                         <img src="/img/${item.banner}" alt="${item.name}" class="card-img-top img-fluid"/>
//                         <div class="card-body">
//                             <h3>${item.name}</h3>
//                             <h2>
//                                 <b>${item.Date}</b>
//                             </h2>
//                             <a href="#">Tickets</a>
//                         </div>
//                     </div>
//                 </div>`;
// }

// $(document).ready(function () {
//     getProducts();

//     $("#category").on('change', function () {
//         filters.categories = $(this).val();
//         getProducts();
//     });
// });

// function getProducts() {
//     $.ajax({
//         url: `/api/v1/event`,
//         data: filters,
//         traditional: true,
//         success: function (data, status, xhr) {
//             $("#items").empty().append($.map(data, createItem));
//             const count = xhr.getResponseHeader('x-total-count');
//             addPaginationButtons(filters.page, count, filters.pageSize);
//         }
//     });
// }

// function addPaginationButtons(currentPage, totalCount, pageSize) {
//     const pageCount = Math.ceil(totalCount / pageSize);
//     const buttons = [];
//     for (let i = 1; i <= pageCount; i++) {
//         const button = $('<li>', { class: 'page-item' });
//         if (i === currentPage) {
//             button.addClass('active');
//             button.append(`<a class="page-link" href="#">${i} <span class="sr-only">(current)</span></a>`)
//         } else {
//             button.append(`<a class="page-link" href="#">${i}</a>`)
//         }
//         buttons.push(button);
//     }
//     $('.pagination').empty().append(buttons);
// }


var filteredEvents = [];

var selectedCities = [];
var selectedVenues = [];
var selectedDateFrom;
var selectedDateTo;
var selectedName;
var selectedSortBy;
var selectedSortOrder;

var filterCity ={
    cityName: null,
};
var filterVenue ={
    venueName: null,
    cities: selectedCities.map(i  => i.value)
};
var filterEvent = {
    name: selectedName,
    dateFrom: selectedDateFrom,
    dateTo: selectedDateTo,
    cities: selectedCities.map(i  => i.value),
    venues: selectedVenues.map(i => i.value),
    sortBy: selectedSortBy,
    sortOrder: selectedSortOrder
};

var sortArrows = {
    Asc: 'fa fa-angle-up',
    Desc: 'fa fa-angle-down'
};

Object.defineProperty(filterVenue, 'cities', { get: () => { return  selectedCities.map(i  => i.value)} });

Object.defineProperty(filterEvent, 'name', { get: () => { return  selectedName;} });
Object.defineProperty(filterEvent, 'cities', { get: () => { return  selectedCities.map(i  => i.value)} });
Object.defineProperty(filterEvent, 'venues', { get: () => { return  selectedVenues.map(i => i.value)} });
Object.defineProperty(filterEvent, 'dateFrom', { get: () => { return  selectedDateFrom;} });
Object.defineProperty(filterEvent, 'sortBy', { get: () => { return  selectedSortBy;} });
Object.defineProperty(filterEvent, 'sortOrder', { get: () => { return  selectedSortOrder;} });

function setCity(cityName) {
    $('#cityList').find('li').remove();
    filterCity.cityName = cityName;
    $.ajax({
        url: `/api/v1/City`,
        traditional: true,
        data: filterCity,
        success: (data, status, xhr) => {

            data.forEach(element => {
                if (!selectedCities.some(item => item.value == element.cityId)) {
                    $('#cityList').append($('<li>').attr('value', element.cityId).text(element.name).addClass('list-group-item'));
                }               
            });           
        }    
    });
}

function setVenue() {
    $('#venueList').find('li').remove();    
    $.ajax({
        url: `/api/v1/Venue`,
        traditional: true,
        data: filterVenue,
        success: (data, status, xhr) => {
            data.forEach(element => {
                if (!selectedVenues.some(item => item.value == element.id)) {
                    $('#venueList').append($('<li>').attr('value', element.id).text(element.name).addClass('list-group-item'));
                }              
            });           
        }    
    });
}

function searchEvent() {
    $.ajax({
        url: `/api/v1/Event`,
        traditional: true,
        data: filterEvent,
        success: (data, status, xhr) => {
            setEvents(data);
        }
    });    
}
function setEvents(data) {
    $(".event-items-container").empty();
    filteredEvents = [];
    if (data && data.length > 0) {
        data.forEach(event => {
            filteredEvents.push(event);
            var item = `<div class="event-cart-item">
                            <div>
                                <h5 class="title">${event.name}</h5>
                                <p class="text">${event.date}</p>
                                <p>${event.venue.name}<p>
                                <p>${event.cityName}<p>
                                <div class="d-flex justify-content-center">
                                    <a href="#" class="btn btn-primary btn-block">Tickets</a>
                                </div>             
                            </div>
                        </div>`;

            $(".event-items-container").append(item);       
        });
    } else {
        $(".event-items-container").append('<h3>No data found</h3>');
    }   
}
function setEventList(name) {   
    $('#nameEvent').find('option').remove();
    $.ajax({
        url: `/api/v1/Event/filterByName`,
        traditional: true,
        data: {eventName: name},
        success: (data, status, xhr) => {
            data.forEach(element => {
                    $('#nameEvent').append($('<option>').attr('value', element).addClass('list-group-item'));                             
            });           
        }
    })   
}

$(document).ready(function () {
    setCity();
    setVenue();
    searchEvent();

    //city
    $('#cityEvent').on('change', (e) => {
        var cityName = e.target.value;
        setCity(cityName);
    });
    $('#cityList').on('click', 'li', (e) => {
        selectedCities.push({value: e.target.value, text: e.target.textContent});
        console.log(selectedCities);
        console.log(filterEvent); 
        console.log(filterVenue); 
        $('#cityListSelected').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action bg-success'));
        $('#cityList').find(e.target).remove();
    });

    $('#cityListSelected').on('click', 'li', (e) => {
        selectedCities = selectedCities.filter(item => item.value != e.target.value);
        console.log(selectedCities);
        $('#cityList').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action'));
        $('#cityListSelected').find(e.target).remove();
    });
    //venue
    $('#cityListSelected').on('DOMSubtreeModified', (e) => {
        console.log(e);
        setVenue();
    });
    $('#venueList').on('click', 'li', (e) => {
        selectedVenues.push({value: e.target.value, text: e.target.textContent});
        console.log(selectedCities);
        $('#venueListSelected').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action bg-success'));
        $('#venueList').find(e.target).remove();
    });
    $('#venueListSelected').on('click', 'li', (e) => {
        selectedVenues = selectedCities.filter(item => item.value != e.target.value);
        console.log(selectedVenues);
        $('#venueList').append($('<li>').attr('value', e.target.value).text(e.target.textContent).addClass('list-group-item list-group-item-action'));
        $('#venueListSelected').find(e.target).remove();
    });
    $('#venueEvent').on('change', (e) => {
        filterVenue.venueName = e.target.value;
        setVenue();
    });
    //date
    $('#dateEventFrom').on('change', (e) => {
        selectedDateFrom = e.target.value;
        console.log(selectedDateFrom);
    });
    $('#dateEventTo').on('change', (e) => {
        if(selectedDateFrom && selectedDateFrom > e.target.value) {
            $('#dateEventTo').css('border-color', 'red');
        } else {
            $('#dateEventTo').css('border-color', '');
            selectedDateTo = e.target.value;
            console.log(selectedDateTo);
        }
        
    });
    $('#searchEvent').on('click', () => {
        searchEvent();
    });
    $('#clearEvent').on('click', () => {
        //$('#searchBar').val('');
        //selectedName = null;

        selectedCities = [];
        selectedVenues = [];
        $('#venueListSelected').find('li').remove();
        $('#cityListSelected').find('li').remove();
        setCity();

        $('#dateEventTo').val('');
        $('#dateEventFrom').val('');
        selectedDateFrom = undefined;
        selectedDateTo = undefined;

        searchEvent();  
    });
    $('#searchBar').on('change', (e) => {
        $( "#clearEvent" ).trigger( "click" );
        selectedName = e.target.value;
        searchEvent();
    })   
    $("#searchBar").keyup(function(e){
        if(e.keyCode != 8){ 
         var value = this.value;
         setEventList(value);
         }
      });
    //sort
    $('[class*=sortOpt]').on('click', (e) => {    
        selectedSortBy = e.target.attributes.sortBy.value;
        selectedSortOrder = e.target.attributes.sortDir.value;
        console.log(selectedSortBy + ' '+ sortArrows[selectedSortOrder]);
        $('#sortBar').find('i').remove();
        $('#sortBar').text(selectedSortBy);
        $('#sortBar').append($('<i>').addClass(sortArrows[selectedSortOrder]));
        searchEvent();        
    })
    
});


