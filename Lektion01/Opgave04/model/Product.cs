namespace Opgave04.model;

// Opgave 4: Positional record = uforanderlig (immutable) type med value equality. value equality betyder at to instanser af
// Product med samme værdier for Id, Name, Price og Category vil blive betragtet som lige (equal).
public record Product(
    string Id, string Name, decimal Price, string Category
    );
