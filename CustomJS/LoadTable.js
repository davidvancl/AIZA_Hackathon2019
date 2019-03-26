var PolicieData = new Array();
var HasiciData = new Array();
var ZachrankaData = new Array();
var line;
var completed = false;

var radek;
line = 0;
LoadData("Files/Policie-CR.csv",PolicieData,true,0);
line = 0;
LoadData("Files/Stanice-a-pracoviste-HZS.csv",HasiciData,false,0);
line = 0;
LoadData("Files/Vyjezdove-zakladny-ZZS.csv",ZachrankaData,false,0);

function LoadData(Soubor,witeField,loadToTable,AktualniRadek) {
    Papa.parse(Soubor, {
    download: true,
    before: function()
	{
		line = 0;
	},
    step: function(row) {
        try {
            if(completed){ line = 0;} 
            if(row.data != ""){
                witeField[AktualniRadek] = row.data;

                AktualniRadek++;
        }
        } catch (e) { }
    },
    complete: function() {
            if (loadToTable) {
                ToTable(witeField);
            }
            completed = true;
        
    }
});
    
}
function ToTable(DataUsed){ 

var Write;
    Write += "<thead>";
    Write += StartTr();
for (let index = 0; index < DataUsed[0].length; index++) {        
        Write += ItemH(DataUsed[0][index]);        
}
    Write += EndTr();
    Write += "</thead>";
    Write += "<tbody>";
for (let index = 1; index < DataUsed.length; index++) {

    Write += StartTr();
    for (let index2 = 0; index2 < DataUsed[index].length; index2++) {
        
    Write += Item(DataUsed[index][index2]);
        
    }
    Write += EndTr();
    
}

    Write += "</tbody>";



$('#dataTable').html(Write);

function StartTr() {
    return "<tr>";
  }
  function EndTr() {
    return "</tr>";  
  }

  function Item(data){
    if(data == ""){
        data= "Není záznam"
    }
    var out = ("<td>"+data+"</td>");
    return out;
  }
  function ItemH(data){
    var out = ("<th>"+data+"</th>");
    return out;
  }
}
function datachange(btn) {
    $("#nav-Policie").attr("class","nav-link");
    $("#nav-HZS").attr("class","nav-link");
    $("#nav-ZZS").attr("class","nav-link");
    
    switch (btn) {
        case 'HZS':
            $("#nav-HZS").attr("class","nav-link active");
            ToTable(HasiciData);
            myTable.destroy()
            myTable= $('#dataTable').DataTable();
            break;

        case 'ZZS':
            $("#nav-ZZS").attr("class","nav-link active");
            ToTable(ZachrankaData);
            myTable.destroy()
            myTable= $('#dataTable').DataTable();           
            break;

        case 'Policie':
        default:
            $("#nav-Policie").attr("class","nav-link active");
            ToTable(PolicieData);
            myTable.destroy()
            myTable= $('#dataTable').DataTable();
            break;
    }
}