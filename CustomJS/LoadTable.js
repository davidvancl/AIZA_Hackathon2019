var PolicieDataSet = new Array(),HasiciDataSet = new Array(),ZachrankaDataSet = new Array();
var PolicieTitleSet = [],HasiciTitleSet = [],ZachrankaTitleSet = [];
var test;
LoadData("Files/Policie-CR.csv",PolicieDataSet,PolicieTitleSet,true);
LoadData("Files/Stanice-a-pracoviste-HZS.csv",HasiciDataSet,HasiciTitleSet);
LoadData("Files/Vyjezdove-zakladny-ZZS.csv",ZachrankaDataSet,ZachrankaTitleSet);

function LoadData(Soubor,dataSet,titleSet,load) {
    var RowNumber = 0;
    var FirstRow = true;
    Papa.parse(Soubor, {
    download: true,
    step: function(row) {
        try { 
            
            if(FirstRow){
                FirstRow = false;
                row.data.forEach(element => {
                    var item = {};
                    item ["title"] = element;
                    titleSet.push(item);
                });
            
            }else{
                if(row.data != ""){
                    dataSet[RowNumber] = row.data;    
                    RowNumber++;
                }
            }            
        } catch (e) { }
    },
    complete: function() {
            if(load){
                LoadTable(dataSet,titleSet); 
            }                         
        }
    });
}

var seznamStanicTable;
function LoadTable(dataSet,title) {
    seznamStanicTable = $('#seznamStanic').DataTable( {
        data: dataSet,
        columns: title,       
         "language": {
            "lengthMenu": "Zobraz _MENU_ záznamů na stránku.",
            "zeroRecords": "Nebylo nic nalezeno, zkuste později.",
            "info": "Stránka _PAGE_ z _PAGES_",
            "infoEmpty": "Data nejsou v současné době dostupná",
            "search":         "Vyhledat:",
            "paginate": {
                "first":      "První",
                "last":       "Poslední",
                "next":       "Další",
                "previous":   "Předchozí"
            },
            "infoFiltered": "(filtered from _MAX_ total records)"
        }
    } ); 
}

function datachange(tableType) {
    seznamStanicTable.destroy();
    $('.btn-table').removeClass('active');
    $('.btn-table#'+tableType).addClass("active")
    switch (tableType) {
        
        case "Policie":
            LoadTable(PolicieDataSet,PolicieTitleSet);
            break;
        case "HZS":
            LoadTable(HasiciDataSet,HasiciTitleSet);            
            break;
        case "ZZS":
        default:
            LoadTable(ZachrankaDataSet,ZachrankaTitleSet); 
            break;
    }    
}