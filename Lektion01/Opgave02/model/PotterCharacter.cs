namespace Opgave02.model;

// Opgave 2.1: Model for en Harry Potter karakter.
// Bruger en record, fordi en karakter er et rent dataobjekt (uforanderligt)

public record PotterCharacter(
    string FullName,
    string Nickname,
    string HogwartsHouse,
    string InterpretedBy,
    List<string> Children,
    string Image,
    string Birthdate,
    int Index
    );
