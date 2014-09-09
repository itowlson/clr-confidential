Public Interface IPantaloon
    Sub Wear()
End Interface

Public Interface IAbradable
    Sub Wear()
End Interface

Public Class IllMadeJeans
    Implements IPantaloon, IAbradable

    Sub PutThemOnOneLegAtATime() Implements IPantaloon.Wear

    End Sub

    Sub FallToPieces() Implements IAbradable.Wear

    End Sub

End Class

