function uploadSong() {
    var inputValues = $('.js-uploadSongForm').find('input');
    var artist = $(inputValues[1]).val();
    var title = $(inputValues[2]).val();
    var uploader = $(inputValues[3]).val();

    var file = inputValues[0].files;

    var uploadingModel = new FormData();
    //var newSong = [];

    //newSong = {
    //    artist: artist,
    //    name: title,
    //    extension: "mp3",
    //    path: file[0].name,
    //    style: "HardRock",
    //    uploader: uploader
    //};

    uploadingModel.append('fileSong', file[0]);
    uploadingModel.append('artist', artist);
    uploadingModel.append('name', title);
    uploadingModel.append('extension', "mp3");
    uploadingModel.append('path', file[0].name);
    uploadingModel.append('style', "HardRock");
    uploadingModel.append('uploader', uploader);

    $.ajax({
        type: 'POST',
        data: uploadingModel,
        url: "/Home/UploadSong",
        contentType: false,
        processData: false
    }).done(function (result) {
        alert("File uploaded!");
    });
}